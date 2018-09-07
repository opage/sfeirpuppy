import React from 'react';
import Form from './Form';
import AlertDelete from './Delete';

function User(props) {

  const style = {
    margin: "20px",
    paddingTop: "7px",
    boxShadow: '12px 12px 2px 1px #61DAFB',
    borderRadius: "89px 20px 89px 20px",
    MozBorderRadius: "89px 20px 89px 20px",
    WebkitBorderRadius: "89px 20px 89px 20px",
    border: "0px solid #000000",
    backgroundColor: "#222",
    color: "white"

  };

  const inline = {
    display: "inline",
  }
//onClick={() => props.onClick()}
  return (
  
    <div className="user" style={style}>
      <h2> {props.user.firstName + " " + props.user.lastName} </h2>
      {/* <p className="uid">{props.user.id}</p> */}
      <p className="phone">{props.user.phone}</p>
      <p className="email">{props.user.email}</p>
      <div style={inline} >
      <Form 
      
      uid={props.user.id}
      firstName={props.user.firstName}
      lastName={props.user.lastName}
      phone={props.user.phone}
      adress={props.user.adress}
      city={props.user.city}
      cp={props.user.cp}
      email={props.user.email}
      birthday={props.user.birthday}
      lastModified={props.user.lastModified}
      facebook={props.user.facebook}
      gitHub={props.user.gitHub}
      twitter={props.user.twitter}
      />

      <AlertDelete 
      uid={props.user.id}
      firstName={props.user.firstName}
      lastName={props.user.lastName}
      />
      </div>
    </div>
    
  );
}

export default User;