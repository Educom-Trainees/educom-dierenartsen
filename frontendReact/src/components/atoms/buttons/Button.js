import React from 'react';
import './_button.style.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCalendarDays } from '@fortawesome/free-solid-svg-icons';



function Button(props) {
  const { variant = 'primary', children, ...rest } = props;
  return (
    <button className={`button ${variant}`} {...rest}>
      {children} <FontAwesomeIcon icon={faCalendarDays} /> 
    </button>
  );
}

export default Button;