import React from 'react';
import PropTypes from 'prop-types';
import './_text.style.scss';

const Text = ({ content, size, color, bold, italic, underline }) => {
  const textStyle = {
    fontSize: size,
    color: color,
    fontWeight: bold ? 'bold' : 'normal',
    fontStyle: italic ? 'italic' : 'normal',
    textDecoration: underline ? 'underline' : 'none',
  };

  return (
    <p style={textStyle} className="text-content">
      {content}
    </p>
  );
};

Text.propTypes = {
  content: PropTypes.string.isRequired,
  size: PropTypes.string,
  color: PropTypes.string,
  bold: PropTypes.bool,
  italic: PropTypes.bool,
  underline: PropTypes.bool,
};

export default Text;