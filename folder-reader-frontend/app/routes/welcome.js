import Route from '@ember/routing/route';
import { inject as service } from '@ember/service';


export default Route.extend({

    model: function() {
        this._super(...arguments);
        this.set('_alert', {show: false, message: '', class: '', header: ''});
        let modelResult = {_alert: this.get('_alert')};
    
        return modelResult;
    },

    contentService: service(),


    actions: {
        onGetFolderContent(folderNumber) {
            this.transitionTo('content', folderNumber);
        },

        onShowPathDialog() {
            let pathDialog = prompt('Apsolutna putanja do foldera (u kojem su svi ostali folderi): ', 'C:\\Users\\user');
            if (pathDialog.length != 0) {
                this.get('contentService').saveFolderPath(pathDialog).then(result => {
                    let isSuccess = result.success;
                    Ember.set(this.get('_alert'), 'header', isSuccess ? 'Spremljeno' : 'Greska');
                    Ember.set(this.get('_alert'), 'message', isSuccess  ? 'Putanja ' + pathDialog + ' spremljena.' : result.data);
                    Ember.set(this.get('_alert'), 'class', isSuccess ? 'alert-success' : 'alert-danger');
                    Ember.set(this.get('_alert'), 'show', true);
                });
            }
        },

        onCloseAlert() {
            Ember.set(this.get('_alert'), 'show', false);
        }
    }
});
