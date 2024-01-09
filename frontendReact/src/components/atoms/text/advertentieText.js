import React from 'react';
import './_advertentieText.style.scss';

function advertentieText({ text }) {
  return (
    <div className="advertentie-text">
      <p>{text}</p>
    </div>
  );
}

export default advertentieText;