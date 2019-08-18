import Service from '@ember/service';

export default Service.extend({

    init() {
        this._super(...arguments);
    },

    getFolderContent(folderNumber) {
        return $.ajax({
            method: 'GET',
            url: '/content/' + folderNumber
        }).then(result => {
            return result;
        });
    },

    saveFolderPath(folderPath) {
        return $.ajax({
            method: 'POST',
            url: '/path',
            data: {
                path: folderPath
            }
        }).then(result => {
            return result;
        });
    }
});