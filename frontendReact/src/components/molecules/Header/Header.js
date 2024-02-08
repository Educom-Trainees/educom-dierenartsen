import React from 'react';
import PropTypes from 'prop-types';
import Logo from '../../atoms/logo/LogoAtom';
import './_Header.style.scss'
import MenuTrigger from '../../atoms/MenuTrigger/MenuTrigger';

const Header = ({ logoSrc, logoAlt, menuOptions ,onMenuToggle }) => (
  <div className="header">
    <Logo src={logoSrc} alt={logoAlt} />
    <MenuTrigger options={ menuOptions } onClick={onMenuToggle} />
  </div>
);

Header.propTypes = {
  logoSrc: PropTypes.string.isRequired,
  logoAlt: PropTypes.string.isRequired,
  onMenuToggle: PropTypes.func.isRequired,
};

export default Header;