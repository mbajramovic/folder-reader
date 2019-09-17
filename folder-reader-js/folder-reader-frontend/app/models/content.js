import DS from 'ember-data';
const { Model } = DS;

export default Model.extend({

    folder: DS.attr('string'),
    file: DS.attr('string')
    
});
