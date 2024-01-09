import React from 'react';
import './_IntroText.style.scss';

function IntroText({ text }) {
  return (
    <div className="intro-text">
      <p>{text}</p>
    </div>
  );
}

export default IntroText;