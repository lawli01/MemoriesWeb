
var PhotoList = React.createClass({
    getInitialState: function() {
        return{ data: [] };
    },

    componentDidMount: function () {
        debugger;
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);
            this.setState({ data: response.result });
        }.bind(this);
        xhr.send();
    },

    render: function () {
        var names = this.state.data;
        return (
            <div>
                {names.map(function(object, i) {
                    return <img src={object.image} key={i }/>;
                })}
            </div>
        );
    }
});

const app = document.getElementById('app');

ReactDOM.render(<PhotoList url="/demo/memories"/>, app);
