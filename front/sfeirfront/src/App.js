import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

import User from './User';
import Add from './Add';




class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      users: [
      ],
    };
  }

  componentDidMount() {
    return fetch("http://localhost:5103/api/User/users", // API URL
      //"https://jsonplaceholder.typicode.com/users", // TEST URL
    {
      method: "GET"
    }
  ).then(response => response.json())
  .then(resp => {
   return this.setState({
    users: resp,
   });
  
  });

  }


  render() {
    
    const puppies = this.state.users.map(user => {
      return (
        <li key={user.id}>
          <User user={user} />
        </li>
      );
    });

    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to Sfeir Puppy</h1>
        </header>
        <Add />
        <ul className="App-intro">
          {puppies}
        </ul>
   
      </div>
    );
  }
}

export default App;
