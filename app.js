 Ext.application({
    name: 'App',
    models: ['Base','Employee', 'Manager'],
    stores: ['Employees', 'Managers'],
    showEmployeeManager: function(employee) {

        // Use getManager to load a Manager Model instance for this employee.
        employee.getManager(function (record, operation, success) {

            console.log('Employee: ' + employee.get('lastName') + ', ' + employee.get('firstName'));

            if (record) {
                console.log('Manager: ' + record.get('lastName') + ', ' + record.get('firstName'));
            } else {
                console.log('Manager: Not epecified');
            }

            console.log('----------------------------------------------');
        });
    },
    launch: function () {
        var me = this;
        var employeesStore = Ext.getStore('Employees');
        employeesStore.load(function (records, operation, success) {

            for (i = 0, len = records.length; i < len; i++) {

                var employee = records[i];
                me.showEmployeeManager(employee);
            }
        });
    }
});