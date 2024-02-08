import React, { useState } from 'react';
import './_dataSelector.style.scss';
import Button from '../../atoms/buttons/Button'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronLeft, faChevronRight } from '@fortawesome/free-solid-svg-icons';


const DateBlock = ({ day, date, month, onClick, selected }) => (
    <div className={`date-block ${selected ? 'selected' : ''}`} onClick={onClick}>
      <div className="day">{day}</div>
      <div className="date">{date}</div>
      <div className="month">{month}</div>
      {selected && <div className="selection-indicator"></div>}
    </div>
  );
  
  const DateSelector = () => {
    const [selectedBlock, setSelectedBlock] = useState(null);
  
    const handleBlockClick = (index) => {
      setSelectedBlock(index);
    };
  
    const currentDate = new Date();
    const currentDateNum = currentDate.getDate();
  
    const dateBlocks = Array.from({ length: 5 }, (_, index) => {
      const futureDate = new Date();
      futureDate.setDate(currentDateNum + index);
      return {
        day: futureDate.toLocaleDateString('nl-NL', { weekday: 'short' }),
        date: futureDate.getDate(),
        month: futureDate.toLocaleDateString('nl-NL', { month: 'long' }),
      };
    });
  
    return (
      <div className="date-selector">
        {/* Knop aan de linkerkant */}
          <Button size="extraSmall" icon={faChevronLeft} className="icon-button" />
        {dateBlocks.map((block, index) => (
          <DateBlock
            key={index}
            {...block}
            selected={index === selectedBlock}
            onClick={() => handleBlockClick(index)}
          />
        ))}
        {/* Knop aan de rechterkant */}
        <Button size="extraSmall" icon={faChevronRight} className="icon-button"/>
      </div>
    );
  };
  
  export default DateSelector;