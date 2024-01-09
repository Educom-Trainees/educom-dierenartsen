import React from 'react';
import './_subKop.style.scss';

function subKop({ text }) {
  return (
    <div className="subKop-text">
      <p>{text}</p>
    </div>
  );
}

export default subKop;