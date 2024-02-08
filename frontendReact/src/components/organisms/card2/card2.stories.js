import React from 'react';
import Card2 from './card2';
import { faPersonFalling } from '@fortawesome/free-solid-svg-icons';

export default {
  title: 'Organisms/Card2',
  component: Card2,
};

const Template = (args) => <Card2 {...args} />;

export const ExampleCard2 = Template.bind({});
ExampleCard2.args = {
  buttonBarRow1: [
    { label: 'Knop 1', size: 'large', icon: faPersonFalling, onClick: () => alert('Knop 1 geklikt') },
    { label: 'Knop 2', size: 'large', onClick: () => alert('Knop 2 geklikt') },
  ],
  buttonBarRow2: [
    { label: 'Knop 4', onClick: () => alert('Knop 4 geklikt') },
    { label: 'Knop 5', onClick: () => alert('Knop 5 geklikt') },
    { label: 'Knop 6', onClick: () => alert('Knop 6 geklikt') },
    { label: 'Knop 7', onClick: () => alert('Knop 7 geklikt') },
  ],
  buttonBarRow3: [
    { label: 'Knop 9', size: 'medium', onClick: () => alert('Knop 9 geklikt') },
    { label: 'Knop 10', onClick: () => alert('Knop 10 geklikt') },
    { label: 'Knop 11', onClick: () => alert('Knop 11 geklikt') },
    { label: 'Knop 12', onClick: () => alert('Knop 12 geklikt') },
    { label: 'Knop 13', onClick: () => alert('Knop 13 geklikt') },
    { label: 'Knop 14', onClick: () => alert('Knop 14 geklikt') },
  ],
  dropdownOptions: ['Optie 1', 'Optie 2', 'Optie 3'],
  icon: /* Voeg hier je FontAwesome-icon toe */ null,
};
