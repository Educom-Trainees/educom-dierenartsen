import React, { useState } from 'react';
import PropTypes from 'prop-types';
import './_toggleButton.style.scss'; // Hernoem de styling naar ToggleButton.scss
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faDog } from '@fortawesome/free-solid-svg-icons';

function ToggleButton({ onClick }) {
    const [isToggled, setToggled] = useState(false);
  
    const handleClick = () => {
      setToggled(!isToggled);
  
      // Call the provided onClick callback
      if (onClick) {
        onClick(!isToggled);
      }
    };
  
    return (
      <div className={`toggle-button-container ${isToggled ? 'toggled' : ''}`}>
        <button className={`button button--large ${isToggled ? 'hidden' : ''}`} onClick={handleClick}>
          <FontAwesomeIcon icon={faDog} size="2x" />
        </button>
        <div className={`button-container ${isToggled ? 'visible' : ''}`}>
          <button className="button button--small" onClick={handleClick}>
            <FontAwesomeIcon icon={faDog} size="1x" />
          </button>
          <button className="button button--extra-small" onClick={handleClick}>
            <FontAwesomeIcon icon={faDog} size="lg" />
          </button>
        </div>
      </div>
    );
  }
  
  ToggleButton.propTypes = {
    onClick: PropTypes.func,
  };
  
  export default ToggleButton;