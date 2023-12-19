import React from 'react';
import logoImage from './logoHappyPaw.png';

const LogoAtom = ({ alt }) => {
  return (
    <img src={logoImage} alt={alt} />
  );
};

export default LogoAtom;
