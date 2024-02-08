import React from 'react';
import PropTypes from 'prop-types';
import Paragraph from '../../atoms/paragraph/Paragraph';

const ParagraphMolecule = ({ content1, content2, size1, size2, ...props }) => {
  return (
    <div className="paragraph-molecule">
      <Paragraph content={content1} size={size1} {...props} />
      <Paragraph content={content2} size={size2} {...props} />
    </div>
  );
};

ParagraphMolecule.propTypes = {
  content1: PropTypes.string,
  content2: PropTypes.string,
  size1: PropTypes.oneOf(['small', 'medium', 'large']),
  size2: PropTypes.oneOf(['small', 'medium', 'large']),
};

export default ParagraphMolecule;