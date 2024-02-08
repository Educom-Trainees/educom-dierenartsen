import React from 'react';
import PropTypes from 'prop-types';
import './_buttonBar.style.scss';
import Button from '../../atoms/buttons/Button';

const ButtonBar = ({ buttons }) => {
  return (
    <div className="ButtonBar">
      {buttons.map((button, index) => (
        <Button
          key={`btn-${index}`}
          primary={button.primary}
          size={button.size}
          variant={button.variant}
          icon={button.icon} // Gebruik de button.icon als het beschikbaar is, anders gebruik de meegegeven icon prop
          label={button.label}
          onClick={button.onClick}
        />
      ))}
    </div>
  );
};

ButtonBar.propTypes = {
  buttons: PropTypes.arrayOf(
    PropTypes.shape({
      primary: PropTypes.bool,
      size: PropTypes.oneOf(['extraSmall', 'small', 'medium', 'large']),
      variant: PropTypes.string,
      icon: PropTypes.string,
      label: PropTypes.string.isRequired,
      onClick: PropTypes.func,
    })
  ).isRequired,
};

export default ButtonBar;