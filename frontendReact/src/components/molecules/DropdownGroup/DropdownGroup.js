import React from 'react';
import PropTypes from 'prop-types';
import './_dropdownGroup.style.scss';
import Dropdown from '../../atoms/dropdowns/Dropdown';

const DropdownGroup = ({ texts = [], icons = [], dropdowns = [] }) => {
  return (
    <div className="DropdownGroup">
      {texts.map((text, index) => (
        <div key={`text-${index}`} className="dropdown-container">
          <div className="dropdown-text">
            {text}
          </div>
          <Dropdown
            options={dropdowns[index]?.options || []}
            onSelect={dropdowns[index]?.onSelect || (() => {})}
            icon={icons[index]} 
          />
        </div>
      ))}
    </div>
  );
};

DropdownGroup.propTypes = {
  texts: PropTypes.arrayOf(PropTypes.string).isRequired,
  icons: PropTypes.arrayOf(PropTypes.object), 
  dropdowns: PropTypes.arrayOf(
    PropTypes.shape({
      options: PropTypes.arrayOf(PropTypes.string).isRequired,
      onSelect: PropTypes.func,
    })
  ).isRequired,
};

export default DropdownGroup;