import React from 'react';
import PropTypes from 'prop-types';
import Input from '../../atoms/inputfield/InputField';
// import './_cardWithInputs.style.scss';

const CardWithInputs = ({ title }) => {
  const handleInputChange = (index, value) => {
    console.log(`Input ${index + 1} gewijzigd naar: ${value}`);
  };

  return (
    <div className="CardWithInputs">
      <h2 className="card-title">{title}</h2>
      <div className="input-container">
        {[...Array(6).keys()].map((_, index) => (
          <Input
            key={index}
            type="text"
            placeholder={`Input ${index + 1}`}
            // value=
            onChange={(e) => handleInputChange(index, e.target.value)}
          />
        ))}
      </div>
    </div>
  );
};

CardWithInputs.propTypes = {
  title: PropTypes.string.isRequired,
};

export default CardWithInputs;