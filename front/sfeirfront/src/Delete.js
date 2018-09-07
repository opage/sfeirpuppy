import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

class AlertDelete extends React.Component {
  state = {
    open: false,
  };

  handleClickOpen = () => {
    this.setState({ open: true });
  };

  handleClose = () => {
    this.setState({ open: false });
  };

  handleDelete = () => {
    fetch(`http://localhost:5103/api/User/${this.props.uid}`,
    {
      method: "DELETE",
      headers: {
        "accept": "application/json",
        "Content-Type": "application/json"
      }
    }
  ).then(response => response.json())
  .catch(e => console.log(e));

  this.handleClose();
  }

  render() {

    const styleButton = {
      color: "#F46036",
      borderColor: "#414770",
      borderStyle: "solid",
      borderWidth: "2px 2px 2px 2px",
      marginBottom: "13px",
      marginLeft: "7px"
    };

    const inline = {
      display: "inline",
    }

    return (
      <div style={inline}>
        <Button style={styleButton} onClick={this.handleClickOpen}>Delete this User</Button>
        <Dialog
          open={this.state.open}
          onClose={this.handleClose}
          aria-labelledby="alert-dialog-title"
          aria-describedby="alert-dialog-description"
        >
          <DialogTitle id="alert-dialog-title">{"Are you really really sure ??"}</DialogTitle>
          <DialogContent>
            <DialogContentText id="alert-dialog-description">
              Do you really want to delete everything about {this.props.firstName + " " + this.props.lastName} ? ;(
            </DialogContentText>
          </DialogContent>
          <DialogActions>
            <Button onClick={this.handleDelete} color="primary">
              Delete Diss
            </Button>
            <Button onClick={this.handleClose} color="primary" autoFocus>
              Cancel
            </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}

export default AlertDelete;