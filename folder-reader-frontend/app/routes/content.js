import Route from '@ember/routing/route';
import { inject as service } from '@ember/service';

export default Route.extend({

    model: function(params) {
        this._super(...arguments);
        this._getContent(params.folderNumber);
        this.set('_alert', {show: false, message: '', class: '', header: ''});
        this.set('_items', {items: []});
        let modelResult = {_alert: this.get('_alert'), _items: this.get('_items')};

        return modelResult;
    },

    // --------------------------------------------------------------------------
    // Private Properties
    // --------------------------------------------------------------------------

    /**
     * Service that handles communications with server.
     * @type {ContentService}
     */
    contentService: service(),

    // --------------------------------------------------------------------------
    // Private Methods
    // --------------------------------------------------------------------------

    /**
     * Method that calls Content Service to send request and get folder content.
     * @param folderNumber 
     */

    _getContent(folderNumber) {
        this.get('contentService').getFolderContent(folderNumber).then(result => {
            if (!result.success) {
                Ember.set(this.get('_alert'), 'header', 'Greska');
                Ember.set(this.get('_alert'), 'message', result.data);
                Ember.set(this.get('_alert'), 'class', 'alert-danger');
                Ember.set(this.get('_alert'), 'show', true);
            }
            else {
                Ember.set(this.get('_items'), 'items', result.data);
            }
        });
    },

    // --------------------------------------------------------------------------
    // Ember Component Definition
    // --------------------------------------------------------------------------

    actions: {
        onCloseAlert() {
            Ember.set(this.get('_alert'), 'show', false);
            if (this.get('_alert.class') === 'alert-danger') {
                this.transitionTo('welcome');
            } 
        },

        onGoBack() {
            this.transitionTo('welcome');
        }
    }
});
