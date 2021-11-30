import { Component } from "react";
import { createPortal } from "react-dom";

class DelayedPortal extends Component {
	constructor(props) {
		super(props);

		this.node = document.createElement("div");
		this.state = {
			// This lags the `isOpen` prop by the specified delays
			isOpen: false,
			willChangeTo: null,
		};
	}

	render() {
		// Don't render anything unless there is something to display
		if (!this.props.isOpen && !this.state.isOpen && !this.state.willChangeTo) {
			return null;
		}

		return createPortal(
			this.props.children({
				isOpen: this.state.isOpen,
				willOpen: this.state.willChangeTo === "open",
				willClose: this.state.willChangeTo === "closed",
			}),
			this.node
		);
	}

	componentDidMount() {
		document.body.appendChild(this.node);

		if (this.props.isOpen) {
			this.open();
		}
	}

	componentDidUpdate(prevProps) {
		if (this.props.isOpen && !prevProps.isOpen) {
			this.open();
		} else if (!this.props.isOpen && prevProps.isOpen) {
			this.close();
		}
	}

	open() {
		this.cancelQueue();

		// Force a reflow, so that a transition will be rendered
		// between the initial state, and the state that results
		// from setting `willChangeTo = "open"`.
		this.node && this.node.scrollTop;

		this.setState({
			willChangeTo: "open",
		});

		this.didChangeTimeout = setTimeout(() => {
			this.setState({
				isOpen: true,
				willChangeTo: null,
			});
			delete this.didChangeTimeout;
		}, this.props.openDelay);
	}

	close() {
		this.cancelQueue();

		this.setState({
			willChangeTo: "closed",
		});

		this.didChangeTimeout = setTimeout(() => {
			this.setState({
				isOpen: false,
				willChangeTo: null,
			});
			delete this.didChangeTimeout;
		}, this.props.closeDelay);
	}

	cancelQueue() {
		if (this.didChangeTimeout) {
			clearTimeout(this.didChangeTimeout);
			delete this.didChangeTimeout;
		}
	}

	componentWillUnmount() {
		document.body.removeChild(this.node);
		delete this.node;
		this.cancelQueue();
	}
}

export default DelayedPortal;
