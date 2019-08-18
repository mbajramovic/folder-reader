import Component from '@ember/component';

export default Component.extend({

    // --------------------------------------------------------------------------
    // API Events
    // --------------------------------------------------------------------------

    /**
     * On show-content is called whenever user clicks on Show Content button. The 
     * only parameter is folder name (number).
     */
    'on-show-content': null,

    // --------------------------------------------------------------------------
    // Private Properties
    // --------------------------------------------------------------------------

    /**
     * Folder number is six-digit number used as name of the folder.
     * @type {String}
     */
    _folderNumber: '',

    /**
     * Flag that indicates if the folder name is correct (six-digit number).
     * @type {Boolean}
     */
    _isDisabled: true,

    // --------------------------------------------------------------------------
    // Private Methods
    // --------------------------------------------------------------------------

    /**
     * Method that checks if folder name is correct.
     */
    _validateInput() {
        if (this.get('_folderNumber').match(/^[0-9]{6}$/g)) {
            this.set('_isDisabled', false);
        }
        else {
            this.set('_isDisabled', true);
        }
    },

    // --------------------------------------------------------------------------
    // Ember Component Definitions
    // --------------------------------------------------------------------------

    actions: {
        onClick() {
            this.sendAction('on-show-content', this.get('_folderNumber'));
        },

        onInputChange() {
            this._validateInput();
        }
    }
});
