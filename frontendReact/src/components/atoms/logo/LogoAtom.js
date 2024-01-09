import React from 'react';
import logoImage from './logoHappyPaw.png';
import './_logo.style.scss'

const LogoAtom = ({ alt }) => {
  return (
    <img className="logo" src={logoImage} alt={alt} />
  );
};

export default LogoAtom;
