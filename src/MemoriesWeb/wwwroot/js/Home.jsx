 var App = React.createClass({

		getInitialState: function(){
			return{data: ''};
		},

		componentWillMount: function(){
		var xhr = new XMLHttpRequest();
		xhr.open('get', this.props.url, true);
		xhr.onload = function() {
		  var response = JSON.parse(xhr.responseText);

		  this.setState({ data: response.result });
		}.bind(this);
		xhr.send();
	},

        render: function(){
            return(
                <h1>{this.state.data}</h1>
            );
        }
});

ReactDOM.render(<App url="/photos" />, document.getElementById('content'));
