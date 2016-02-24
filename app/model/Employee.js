Ext.define('App.model.Employee', {
    extend: 'App.model.Base',
    fields: [
        {
            name: 'managerNumber',
            type: 'int',
            reference: {
                type: 'Manager',
                association: 'EmployeesByManager',
                role: 'manager',        // This adds the getManager method to the Employee model.
                inverse: 'employees'          
            },
            unique: true
        }
    ]
});