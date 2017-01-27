// Here we will create react component for generate form with validation

//React component for input component
var MyInput = React.createClass({
    //onchange event
    handleChange: function (e) {
        this.props.onChange(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    handleClick: function (e) {
        this.props.onClick(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    //validation function
    isValid: function (input) {
        //check required field
        if (input.getAttribute('required') != null && input.value ==="") {
            input.classList.add('error'); //add class error
            input.nextSibling.textContent = this.props.messageRequired; // show error message
            return false;
        }
        else {
            input.classList.remove('error');
            input.nextSibling.textContent = "";
        }
        //check data type // here I will show you email validation // we can add more and will later
        if (input.getAttribute('type') == "email" && input.value != "") {
            if (!this.validateEmail(input.value)) {
                input.classList.add('error');
                input.nextSibling.textContent = this.props.messageEmail;
                return false;
            }
            else {
                input.classList.remove('error');
                input.nextSibling.textContent = "";
            }
        }
        return true;
    },
    //email validation function
    validateEmail: function (value) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(value);
    },
    componentDidMount: function () {
        if (this.props.onComponentMounted) {
            this.props.onComponentMounted(this); //register this input in the form
        }
    },
    
    //render
    render: function () {
        var inputField;
        if (this.props.type == 'textarea') {
            inputField = <textarea value={this.props.value} ref={this.props.name} name={this.props.name}
                                   className='form-control' required={this.props.isrequired} onChange={this.handleChange} />
        }
        else {
            inputField = <input type={this.props.type} value={this.props.value} ref={this.props.name} name={this.props.name}
                                className='form-control' required={this.props.isrequired} onChange={this.handleChange} />
            }
        return (
                <div className="form-group">
                    <label htmlFor={this.props.htmlFor}>{this.props.label}:</label>{inputField}
                    <span className="error"></span>
                </div>
            );
    }
});


// CHILD
var ImageList = React.createClass({
    render: function() {
       var createItem = function(image, index) {
           return <div id='image' key={ index } className="img">
                    <img onClick={ this.props.onClick.bind(null, image )} src={ image }/>
                  </div>;
    }.bind(this);
        return <div id='images' className="topContainer">{ this.props.images.map(createItem)}</div>;
    }
});

//React component for generate form

var ContactForm = React.createClass({
    //get initial state enent
    getInitialState : function(){
        return {
            Name : '',
            Email:'',
            Description : '',
            Fields : [],
            ServerMessage: '',
            data: [],
            Image:''
        }
    },
    // submit function
    handleSubmit : function(e){
        e.preventDefault();
        //Validate entire form here
        var validForm = true;
        this.state.Fields.forEach(function(field){
            if (typeof field.isValid === "function") {
                var validField = field.isValid(field.refs[field.props.name]);
                validForm = validForm && validField;
            }
        });
        //after validation complete post to server
        if (validForm) {
            var d = {
                Name: this.state.Name,
                Email : this.state.Email,
                Description: this.state.Description,
                UploadDate: new Date().toISOString(),
                Image: this.state.Image
            }

            $.ajax({
                type:"POST",
                url : this.props.urlPost,
                data : d,
                success: function(data){
                    //Will clear form here
                    this.setState({
                        Name : '',
                        Email  : '',
                        Description : '',
                        ServerMessage: data.message
                    });
                }.bind(this),
                error : function(e){
                    console.log(e);
                    alert('Error! Please try again');
                }
            });
        }
    },
    //handle change full name
    onChangeName : function(value){
        this.setState({
            Name : value
        });
    },
    //handle chnage email
    onChangeEmail : function(value){
        this.setState({
            Email : value
        });
    },
    //handle change message
    onChangeDescription : function(value){
        this.setState({
            Description : value
        });
    },
    handleOnAdd: function (image, e) {
        this.setState({
            Image: image
        });
    },
    //register input controls
    register : function(field){
        var s = this.state.Fields;
        s.push(field);
        this.setState({
            Fields : s
        })
    },
    componentDidMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);
            this.setState({ data: response.result });
        }.bind(this);
        xhr.send();
    },
    //render
    render: function () {
        //Render form
        return (
            <form name="contactForm" noValidate onSubmit={this.handleSubmit}>
                <ImageList onClick={ this.handleOnAdd } images={ this.state.data } />
                <MyInput type={'text'} value={this.state.Name} label={'Name'} name={'Name'} htmlFor={'Name'} isrequired={true}
                         onChange={this.onChangeName} onComponentMounted={this.register} messageRequired={'Name required'} />
                <MyInput type={'email'} value={this.state.Email} label={'Email'} name={'Email'} htmlFor={'Email'} isrequired={false}
                         onChange={this.onChangeEmail} onComponentMounted={this.register} messageRequired={'Invalid Email'} />
                <MyInput type={'textarea'} value={this.state.Description} label={'Description'} name={'Description'} htmlFor={'Description'} isrequired={true}
                         onChange={this.onChangeDescription} onComponentMounted={this.register} messageRequired={'Description required'} />
                <button type="submit" className="btn btn-default">Submit</button>
                <p className="servermessage">{this.state.ServerMessage}</p>
            </form>
        );
    }
});

//Render react component into the page
ReactDOM.render(<ContactForm urlPost="/manage/SaveContactData" url="/photos" />, document.getElementById('contactFormArea'));


