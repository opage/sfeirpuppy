import React from 'react';

import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

export default class Form extends React.Component {
  constructor(props) {
    super(props);
  
      // pré formatage des dates
      if (this.props.birthday !== "") {
        let bDate = new Date(this.props.birthday);
        let bMonth = bDate.getMonth();
        if (bMonth + 1 < 10) {
          bMonth = "0" + (bMonth + 1);
        } else {
          bMonth++;
        }
        let bDay = bDate.getDate() < 10 ? "0" + bDate.getDate() : bDate.getDate();
        // création d'une variable qui contiendra la date formatée
        this.birthday = bDate.getFullYear() + "-" + bMonth + '-' + bDay;
      }
    
  }

  state = {
    open: false,
  };

  handleClickOpen = () => {
    this.setState({ open: true });
  };

  handleClose = () => {
    this.setState({ open: false });
  };

  onSubmit = () => {
    //instance new object
    var obj = {};
    obj.id = this.props.uid;
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
    fetch(`http://localhost:5103/api/User/${obj.id}`,
    {
      method: "PUT",
      headers: {
        "accept": "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify(obj)
    }   
  ).then(response => console.log(response))
  .catch(e => console.log(e));
  
    this.handleClose();
  };

  

  render() {

    const styleButton = {
      color: "white",
      borderColor: "#61DAFB",
      borderStyle: "solid",
      borderWidth: "2px 2px 2px 2px",
      marginBottom: "13px",
      marginRight: "7px"
    };

    const inline = {
      display: "inline",
    }

    return (
      <div style={inline}>
        <Button style={styleButton} onClick={this.handleClickOpen}>Modify this User's Info</Button>
        <Dialog
          open={this.state.open}
          onClose={this.handleClose}
          aria-labelledby="form-dialog-title"
        >
          <DialogTitle id="form-dialog-title">{this.props.firstName + " " + this.props.lastName}</DialogTitle>
          <DialogContent>
            <DialogContentText>
              What's new pussycat ?
            </DialogContentText>
            <TextField
              autoFocus
              margin="dense"
              id="firstName"
              name="firstName"
              label="Prénom"
              type="text"
              defaultValue={this.props.firstName}
              required
              fullWidth
            />
            <TextField 
              margin="dense"
              id="lastName"
              name="lastName"
              label="Nom"
              type="text"
              defaultValue={this.props.lastName}
              required
              fullWidth
            />
            <TextField
              margin="dense"
              id="phone"
              name="phone"
              label="Téléphone"
              type="text"
              defaultValue={this.props.phone}
              fullWidth
            />
            <TextField
              margin="dense"
              id="email"
              name="email"
              label="Email"
              type="email"
              defaultValue={this.props.email}
              fullWidth
            />
            <TextField
              margin="dense"
              id="adress"
              name="adress"
              label="Adresse"
              type="text"
              defaultValue={this.props.adress}
              fullWidth
            />
            <TextField
              margin="dense"
              id="city"
              name="city"
              label="Ville"
              type="text"
              defaultValue={this.props.city}
              fullWidth
            />
            <TextField
              margin="dense"
              id="cp"
              name="cp"
              label="Code Postal"
              type="text"
              defaultValue={this.props.cp}
              fullWidth
            />
            <TextField
              margin="dense"
              id="birthday"
              name="birthday"
              label="Né(e) le"
              type="date"
              defaultValue={this.birthday}
              fullWidth
            />
            <TextField
              margin="dense"
              id="facebook"
              name="facebook"
              label="Facebook"
              type="text"
              defaultValue={this.props.facebook}
              fullWidth
            />
            <TextField
              margin="dense"
              id="gitHub"
              name="gitHub"
              label="Github"
              type="text"
              defaultValue={this.props.gitHub}
              fullWidth
            />
            <TextField
              margin="dense"
              id="twitter"
              name="twitter"
              label="Twitter"
              type="text"
              defaultValue={this.props.twitter}
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