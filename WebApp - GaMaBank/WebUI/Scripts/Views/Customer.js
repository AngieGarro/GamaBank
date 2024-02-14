//Controlador JS de la vista Customer.cshtml
function CustomerView() {

    this.ViewName = "CustomerView";
    this.ApiUrl = "";

    this.InitView = function () {
        $("btnCreate").click(function () {
            var view = new CustomerView();
            view.CreateCustomer();
        });

        $("btnUpdate").click(function () {
            var view = new CustomerView();
            view.UpdateCustomer;
        });

        $("btnDelete").click(function () {
            var view = new CustomerView();
            view.DeleteCustomer;
        });


        $("btnSearch").click(function () {
            var view = new CustomerView();
            view.RetrieveById;
        });
    }
   
    this.CreateCustomer = function () {
        var customer = {};
        customer.Id = $("txtId").val();
        customer.Name = $("txtName").val();
        customer.LastName = $("txtLastName").val();
        customer.Email = $("txtEmail").val();
        customer.Phone = $("txtPhone").val();

        var ctrlActions = new ControlActions();
        ctrlActions.PostToAPI("Customer/Create", customer, function () {
            alert("Customer creado.");
        })

       
    }

    this.UpdateCustomer = function () {
        var customer = {};
        customer.Id = $("txtId").val();
        customer.Name = $("txtName").val();
        customer.LastName = $("txtLastName").val();
        customer.Email = $("txtEmail").val();
        customer.Phone = $("txtPhone").val();

        var ctrlActions = new ControlActions();
        ctrlActions.PutToAPI("Customer/Update", customer, function () {
            alert("Customer actualizado.");
        })
    }

    this.RetrieveById = function () {
        var ctrlActions = new ControlActions();
        var customerId = $("txtId").val();
        ctrlActions.GetToApi("Customer/RetriveById?id=", customerId, function (customer) {
            $("txtName").val(customer.Name);
            $("txtLastName").val(customer.LastName);
            $("txtEmail").val(customer.Email);
            $("txtPhone").val(customer.Phone);
    })

    this.DeleteCustomer = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, customerData);
        //Refresca la tabla
        this.ReloadTable();
    }

   
}

//Instanciamiento inicial, siempre se ejecuta cuando la pagina termina de cargar.
$(document).ready(function () {
    var view = new CustomerView();
    view.InitView();
})