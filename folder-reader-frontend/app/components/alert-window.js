import Component from '@ember/component';

export default Component.extend({

    actions: {
        onClose() {
            this.sendAction('on-close');
        }
    }
});
