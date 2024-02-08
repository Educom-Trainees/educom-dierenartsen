import React from 'react';
import PropTypes from 'prop-types';

function FooterText({ text }) {
  return <p>{text}</p>;
}

FooterText.propTypes = {
  text: PropTypes.string.isRequired,
};

export default FooterText;