import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import './progressBar.style.scss';

const Progressbar = ({ progressFilled }) => {
  const [filled, setFilled] = useState(0);
  const [isRunning, setIsRunning] = useState(false);

  useEffect(() => {
    if (filled < 100 && isRunning) {
      const timeoutId = setTimeout(() => setFilled((prev) => prev + 2), 50);
      return () => clearTimeout(timeoutId);
    }
  }, [filled, isRunning]);

  // Update the filled state based on the progressFilled prop
  useEffect(() => {
    setFilled(progressFilled);
  }, [progressFilled]);

  return (
    <div>
      <div className="progressbar">
        <div
          style={{
            height: '100%',
            width: `${filled}%`,
            backgroundColor: '#a66cff',
            transition: 'width 0.5s',
          }}
        ></div>
        <span className="progressPercent">{filled}%</span>
      </div>
      <button className="btn" onClick={() => setIsRunning(true)}>
      </button>
    </div>
  );
};

Progressbar.propTypes = {
  progressFilled: PropTypes.number.isRequired,
};

export default Progressbar;