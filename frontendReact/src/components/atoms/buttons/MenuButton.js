import React from 'react';
import './_menuButton.styles.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars } from '@fortawesome/free-solid-svg-icons';

function MenuButton(props) {
  const { children, ...rest } = props;
  return (
    <button className="menu-button" {...rest}>
      <FontAwesomeIcon icon={faBars} />
      {children}
    </button>
  );
}

export default MenuButton;