import React from 'react';
import PropTypes from 'prop-types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './FooterSocials.style.scss';

function SocialFooter({ socialIcons }) {
  return (
    <div className="SocialFooter">
      <div className="social-row">
        {socialIcons.map((icon, index) => (
          <a key={index} href={icon.link} target="_blank" rel="noopener noreferrer">
            <FontAwesomeIcon icon={icon.icon}  />
          </a>
        ))}
      </div>
    </div>
  );
}

SocialFooter.propTypes = {
  socialIcons: PropTypes.arrayOf(
    PropTypes.shape({
      icon: PropTypes.object.isRequired,
      link: PropTypes.string.isRequired,
    })
  ).isRequired,
};

export default SocialFooter;