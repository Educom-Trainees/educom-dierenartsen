import React from 'react';
import homeImage from './dogcat.jpeg';
// import './_logo.style.scss'

const HomeImage = ({ alt }) => {
  return (
    <img className="homeImage" src={homeImage} alt={alt} />
  );
};

export default HomeImage;
