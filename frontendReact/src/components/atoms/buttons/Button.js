import React from 'react';
import PropTypes from 'prop-types';
import './_button.style.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

function Button({ primary, size, variant, icon, label, ...props }) {
  return (
    <button className={`button  ${size} ${variant}`} {...props}>
      {label && <span className="button-text">{label}</span>}
      {icon && <FontAwesomeIcon icon={icon} />}
    </button>
  );
}

Button.propTypes = {
  size: PropTypes.oneOf(['extraSmall', 'small', 'medium', 'large']),
  variant: PropTypes.oneOf(['primary', 'secondary']),
  children: PropTypes.string.isRequired,
  onClick: PropTypes.func,
};

Button.defaultProps = {
  primary: false,
  size: 'medium',
  variant: '',
  onClick: undefined,
};

export default Button;