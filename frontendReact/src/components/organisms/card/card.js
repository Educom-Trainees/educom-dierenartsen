import React from 'react';
import PropTypes from 'prop-types';
import './_card.style.scss';
// import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import ButtonBar from '../../molecules/ButtonBar/ButtonBar';
import DropdownGroup from '../../molecules/DropdownGroup/DropdownGroup';
import Text from '../../atoms/text/Text';
import DateSelector from '../../molecules/DataSelector/DataSelector';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {faCircle} from '@fortawesome/free-solid-svg-icons';

const Card = ({ title, buttonBarData, dropdownGroupData,dateSelectorData, icon }) => {
  return (
    <div className="Card">
      {/* <Text content={title} size="20px" bold className="card-title" /> */}
      
      {/* Eerste rij met de DateSelector molecule */}
      <div className='first-row'>
        <div className='text-first-row'>
          <Text content="Kies een Datum" size="28px" />
          <div className='beschikbaarheid'>
            <div className='beschikbaar'>
              <Text content="Beschikbaar" size="12px" />
              <FontAwesomeIcon icon={faCircle} className="availability-icon-left" /> {/* Toegevoegde FontAwesome icon */}
            </div>
            <div className='niet-beschikbaar'>
              <Text content="Niet beschikbaar" size="12px"/>
              <FontAwesomeIcon icon={faCircle} className="availability-icon-right" /> {/* Toegevoegde FontAwesome icon */}
            </div>
          </div>
        </div>
        <div className='dataSelector'>
          <DateSelector {...dateSelectorData} icon={icon}/>
        </div>
      </div>

      {/* Tweede rij met ButtonBar */}
      <div className='second-row'>
        <div className='text-second-row'>
          <Text content="Clinici" size="28px" />
        </div>
          <ButtonBar buttons={buttonBarData.slice(0, 3)} icon={icon} />
      </div>
      
      {/* Derde rij met 2 Dropdowns */}

      <div className='third-row'>
        <div className='dropdown-group'>
        <Text content="Tijdstip" size="28px" />
          <DropdownGroup {...dropdownGroupData} />
      </div>
    </div>
      
      {/* Vierde rij met de Next Button */}
      {/* <Text content="Next Button Row" size="16px" bold />
      <ButtonBar buttons={[{ label: nextButtonLabel, size: 'medium' }]} icon={icon} /> */}
    </div>
  );
};

Card.propTypes = {
  // title: PropTypes.string.isRequired,
  buttonBarData: PropTypes.array.isRequired,
  // dropdownGroupData: PropTypes.array.isRequired,
  // nextButtonLabel: PropTypes.string.isRequired,
  // nextButtonIcon: PropTypes.object.isRequired,
};

export default Card;