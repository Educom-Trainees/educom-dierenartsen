import React, { useState } from 'react'
import './_dropdown.style.scss';
import PropTypes from 'prop-types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const Dropdown = ({ options, onSelect, icon, secondaryVariant }) => {
    const [isOpen, setIsOpen] = useState(false);
    const [selectedOption, setSelectedOption] = useState(options[0]);

    const handleOptionClick = (option) => {
        setSelectedOption(option);
        onSelect && onSelect(option);
        closeDropdown();
    };

    const toggleDropdown = () => {
    setIsOpen(!isOpen);
    };

    const closeDropdown = () => {
    setIsOpen(false);
    };

    return (
        <div className={`dropdown-button ${secondaryVariant ? 'secondary' : ''}`}>
          <button className={`dropdown-toggle ${isOpen ? 'rotateArrow' : ''} ${secondaryVariant ? 'secondary' : ''}`} onClick={toggleDropdown}>
            {selectedOption}
            {icon && <FontAwesomeIcon icon={icon} className={`rotateArrow ${secondaryVariant ? 'secondary' : ''}`} />}
          </button>
          {isOpen && (
            <ul className={`dropdown-list ${isOpen ? 'open' : ''} ${secondaryVariant ? 'secondary' : ''}`}>
              {options.map((option, index) => (
                <li key={index} onClick={() => handleOptionClick(option)} 
                className={`dropdown-option ${secondaryVariant ? 'secondary' : ''}`}
                >
                  {option}
                </li>
              ))}
            </ul>
          )}
        </div>
      );
};

Dropdown.propTypes = {
    options: PropTypes.arrayOf(PropTypes.string).isRequired,
    onSelect: PropTypes.func,
    secondaryVariant: PropTypes.bool,
  };

export default Dropdown;