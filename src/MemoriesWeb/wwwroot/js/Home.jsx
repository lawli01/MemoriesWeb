var App = React.createClass({
    getInitialState: function() {
        return{ data: [] };
    },

    componentDidMount: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var response = JSON.parse(xhr.responseText);

            this.setState({ data: response.result });
        }.bind(this);
        xhr.send();
    },

    render: function() {
        var names = this.state.data;
        return (
            <div>
                {names.map(function(object, i) {
                return <img src={object} key={i}></img>;
            })}
            </div>
        );
        }
});

ReactDOM.render(<App url="/photos"/>, document.getElementById('content'));
