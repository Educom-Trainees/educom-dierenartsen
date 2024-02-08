import React, { useState } from 'react';
import { Squash as Hamburger } from 'hamburger-react'
import PropTypes from 'prop-types';
import Menu from '../Menu1/Menu1';
import './_menuTrigger.style.scss';

const MenuTrigger = ({ options }) => {
    const [showMenu, setMenu] = useState(false);
  
    return (
      <div className="MenuTrigger">
        <Hamburger
          toggled={showMenu}
          color='white'
          toggle={() => setMenu(!showMenu)}
          className="HamburgerIcon"
        />
        <Menu isOpen={showMenu} options={options}/>
      </div>
    );
  };
  
  MenuTrigger.propTypes = {
    type: PropTypes.string,
    onClick: PropTypes.func.isRequired,
  };
  
  export default MenuTrigger;