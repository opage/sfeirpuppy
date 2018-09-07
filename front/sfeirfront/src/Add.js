import React from 'react';

import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

export default class Form extends React.Component {

  state = {
    open: false,
  };

  handleClickOpen = () => {
    this.setState({open: true});
  };

  handleClose = () => {
    this.setState({ open: false });
  };

  onSubmit = () => {
    //instance new object
    var obj = {};
    // obj.id = this.props.uid;
    obj.firstName = document.getElementById("firstName").value;
    obj.lastName = document.getElementById("lastName").value;
    obj.phone = document.getElementById("phone").value;
    obj.adress = document.getElementById("adress").value;
    obj.city = document.getElementById("city").value;
    obj.cp = document.getElementById("cp").value;
    obj.email = document.getElementById("email").value;
    obj.facebook = document.getElementById("facebook").value;
    obj.gitHub = document.getElementById("gitHub").value;
    obj.twitter = document.getElementById("twitter").value;
    obj.lastModified = new Date();
    fetch(`http://localhost:5103/api/User`,
    {
      method: "POST",
      headers: {
        "accept": "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(obj)
    }   
  ).then(response => response.json())
  .catch(e => console.log(e));
  
    this.handleClose();
  };

  render() {

    const styleButton = {
      backgroundColor: "white",
      borderColor: "#61DAFB",
      borderStyle: "solid",
      borderWidth: "2px 2px 2px 2px",
      marginBottom: "11px",
      marginTop: "7px"
    };

    return (
      <div>
        <Button style={styleButton} onClick={this.handleClickOpen}>Add a new User</Button>
        <Dialog
          open={this.state.open}
          onClose={this.handleClose}
          aria-labelledby="form-dialog-title"
        >
          <DialogTitle id="form-dialog-title">Who is It ?</DialogTitle>
          <DialogContent>
            <DialogContentText>
              A little less conversation, a little more action please
            </DialogContentText>
            <TextField
              autoFocus
              margin="dense"
              id="firstName"
              name="firstName"
              label="Prénom"
              type="text"
              required
              fullWidth
            />
            <TextField 
              margin="dense"
              id="lastName"
              name="lastName"
              label="Nom"
              type="text"
              required
              fullWidth
            />
            <TextField
              margin="dense"
              id="phone"
              name="phone"
              label="Téléphone"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="email"
              name="email"
              label="Email"
              type="email"
              fullWidth
            />
            <TextField
              margin="dense"
              id="adress"
              name="adress"
              label="Adresse"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="city"
              name="city"
              label="Ville"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="cp"
              name="cp"
              label="Code Postal"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="birthday"
              name="birthday"
              label="Né(e) le"
              type="date"
              fullWidth
            />
            <TextField
              margin="dense"
              id="facebook"
              name="facebook"
              label="Facebook"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="gitHub"
              name="gitHub"
              label="Github"
              type="text"
              fullWidth
            />
            <TextField
              margin="dense"
              id="twitter"
              name="twitter"
              label="Twitter"
              type="text"
              fullWidth
            />

          </DialogContent>
          <DialogActions>
            <Button onClick={this.handleClose} color="primary">
              Cancel
            </Button>
            <Button onClick={this.onSubmit} color="primary">
              Save Changes
            </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}