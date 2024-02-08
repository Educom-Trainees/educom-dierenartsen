import React from 'react';
import Card from './card';
import { faHome, faLion, faMouse, faCat, faDog, faArrowRight } from '@fortawesome/free-solid-svg-icons';


// Assuming you have an 'atoms/buttons/Button' component for the buttons
const buttonBarData = [
    { label: 'Geen Voorkeur', size: 'small' },
    { label: 'Karel', size: 'small' },
    { label: 'Danique', size: 'small' },
    { label: '2', size: 'extraSmall' },
    { label: '3', size: 'extraSmall' },
    { label: '4', size: 'extraSmall' },
    { size: 'medium', icon: faDog },
    { size: 'medium', icon: faCat },
    { size: 'medium', icon: faMouse },
    { size: 'medium', icon: faLion },
    { size: 'medium', icon: faDog },
    { size: 'medium', icon: faDog },
    { size: 'medium', icon: faDog },

  ];
  
  const dropdownGroupData = {
    texts: ['Ochtend', 'Namiddag'],
    icons: [faArrowRight], // Assuming no icons for dropdowns
    dropdowns: [
      { options: ['Option 1', 'Option 2', 'Option 3'], onSelect: () => console.log('Selected') },
    ],
  };

  const nextButtonIcon = {
    icons: faArrowRight,
  }
  
  const CardStory = {
    title: 'Organisms/Card',
    component: Card,
    argTypes: {
      title: { control: 'text' },
      nextButtonLabel: { control: 'text' },
      nextButtonIcon: { control: false },
    },
  };
  
  const Template = (args) => <Card {...args} />;
  
  export const Default = Template.bind({});
    Default.args = {
      title: 'Card Title',
      buttonBarData,
      dropdownGroupData,
      // nextButtonLabel: 'Next',
      nextButtonIcon,
};

  
  
  export default CardStory;