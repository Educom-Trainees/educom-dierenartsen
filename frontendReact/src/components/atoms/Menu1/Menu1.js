import React from 'react';
import PropTypes from 'prop-types';
import './_menu1.style.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const Menu = ({ isOpen, options }) => {
  console.log(options);
    return isOpen ? (
      <div className="Menu">
        {options &&
          options.map((option, index) => (
          <p key={index} className='OptionWrapper'>
            <span className="OptionLabel">{option.label}</span>
            <FontAwesomeIcon icon={option.icon} className='OptionIcon'/>
          </p>
        ))}
      </div>
    ) : null;
  };
  
  Menu.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    options: PropTypes.arrayOf(
      PropTypes.shape({
        label: PropTypes.string.isRequired,
        icon: PropTypes.object.isRequired, // Adjust the prop type as needed
      })
    ).isRequired,
  };
  
  export default Menu;