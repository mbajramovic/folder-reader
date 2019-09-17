const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');
const fs = require('fs');
const xml2js = require('xml2js');
const { join } = require('path')


const port = 9000;
const app = express();

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));
app.use(cors());

// -----------------------------------------------------------------------
// API 
// -----------------------------------------------------------------------

/**
 * Route used for editing the path of folder that contains 
 * all other folders.
 */
app.post('/path', function(req, res) {
    const parser = new xml2js.Parser();
    const builder = new xml2js.Builder();
    let path = req.body.path;
    let data = fs.readFileSync('data.xml');
    parser.parseString(data, function(error, data) {
        if (!error && data) {
            data['path'] = path;
            try {
                fs.writeFileSync('data.xml', builder.buildObject(data));
                res.end(JSON.stringify({
                    'success': 'yes'
                }));
            }
            catch(error) {
                res.end(JSON.stringify({
                    'data': 'Došlo je do greške: (' + error + ')'
                }));
            }
        }
        else {
            res.end(JSON.stringify({
                'data': 'Došlo je do greške: (' + error + ')'
            }));
        }
    });
});

app.get('/content/:folderNumber', function(req, res) {
	let folderNumber = req.params.folderNumber;
	if (folderNumber.length != 6) {
		res.end(JSON.stringify({
			data: 'Ime foldera nije validno'
		}));
	}
	else {
		getPath().then(
			result => {
				let folderPath = result;
				if (folderPath.length == 0) {
					res.end(JSON.stringify({
						'data': 'Da bi ste pročitali sadržaj foldera, morate unijeti putanju. (Administrator)'
					}));
				}
				else {
					let folderName = findFolder(folderPath, folderNumber);
					if (folderName.length == 0) {
						res.end(JSON.stringify({
							'data': 'Ne postoji folder koji odgovara unesenom broju.'
						}));
					}
					else {
						let files = walkSync(folderPath + '\\' + folderName);
						res.end(JSON.stringify({
							'success': 'yes',
							'data': files
						}));
					}
				}
			},
			error => {
				res.end(JSON.stringify({
					'data': error
				}));
			}
		);
	}
});

// -----------------------------------------------------------------------
// Helpers
// -----------------------------------------------------------------------

/**
 * Function that returns the path of folder that contains all other folders.
 */
var getPath = function() {
    return new Promise((resolve, reject) => {
        const parser = new xml2js.Parser();
        let data = fs.readFileSync('data.xml');
        parser.parseString(data, function(error, data) {
            if (!error && data) {
                resolve(data['path']);
            }
            else {
                resolve('');
            }
        });
    });
}

/**
 * Function that returns name of folder which contains files for provied folder number.
 * @param folderPath folder that contains all other folders
 * @param folderNumber six-digit number of folder whose name should be returns
 */
var findFolder = function(folderPath, folderNumber) {
    const dirs = fs.readdirSync(folderPath).filter(function (file) {
        return fs.statSync(folderPath+'/'+file).isDirectory();
      });
    for (let i = 0; i < dirs.length; i++) {
        if (dirs[i].includes(folderNumber) || dirs[i].includes(folderNumber.substring(0, 3) + ' ' + folderNumber.substring(3, 6))) {
            return dirs[i];
        }
    }

    return '';
}

/**
 * Function that reads folder content recursively. Function has only one parameter
 * - path to the root folder.
 */
var walkSync = function(dir, filelist) {
	var fs = fs || require('fs'),
		files = fs.readdirSync(dir);
    filelist = filelist || [];
    files.forEach(function(file) {
      if (fs.statSync(dir + '/' + file).isDirectory()) {
    	filelist = walkSync(dir + '/' + file + '/', filelist);
      }
      else {
        filelist.push({
			folder: dir, file: file
		});
      }
    });
    return filelist;
}


app.listen(port);