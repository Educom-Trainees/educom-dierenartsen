import React from 'react';
import PropTypes from 'prop-types';
import FooterText from '../../atoms/text/FooterText';
import './_footer.style.scss'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCopyright } from '@fortawesome/free-regular-svg-icons';

function Footer({ leftText, rightText }) {
  return (
    <div className="Footer">
      <div className="left-text">
        {leftText.map((text, index) => (
          <FooterText key={index} text={text} />
        ))}
      </div>
      <div className="right-text">
        {rightText.map((text, index) => (
          <div key={index} className="footer-text">
            {text}
            {index === rightText.length - 1 && <FontAwesomeIcon icon={faCopyright} />}
          </div>
        ))}
      </div>
    </div>
  );
}

Footer.propTypes = {
  leftText: PropTypes.arrayOf(PropTypes.string).isRequired,
  rightText: PropTypes.arrayOf(PropTypes.string).isRequired,
};

export default Footer;