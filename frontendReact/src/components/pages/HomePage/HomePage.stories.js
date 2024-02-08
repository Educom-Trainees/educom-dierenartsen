import React from 'react';
import HomePage from './HomePage'; // Zorg ervoor dat het juiste pad wordt gebruikt

// Exporteer een object dat de informatie voor het Storybook-verhaal bevat
export default {
  title: 'Pages/HomePage', // Titel voor de Storybook-categorie
  component: HomePage, // Het component waarvoor we een verhaal maken
  argTypes: {
    // Definieer eventuele argumenttypes die u wilt aanpassen in het Storybook-paneel
    // Bijvoorbeeld, als je 'headerData' en 'cardData' wilt aanpassen, kun je ze hier vermelden
    headerData: { control: 'object' },
    cardData: { control: 'object' },
    footerData: { control: 'object' },
  },
};

// Maak een sjabloon dat de SecondPage-component met aangepaste argumenten rendert
const Template = (args) => <HomePage {...args} />;

// Creëer een standaardverhaal dat de component rendert met standaardargumenten
export const Default = Template.bind({});
Default.args = {
  headerData: {
    logoSrc: 'path/to/logo.png',
    logoAlt: 'Logo Alt Text',
    onMenuToggle: () => {
      // Voeg eventuele gewenste logica toe voor het omwisselen van het menu
      console.log('Menu toggled');
    },
  },
  cardData: {
    title: 'Your Card Title',
    buttonBarData: [
      { label: 'Button 1', onClick: () => {} },
      { label: 'Button 2', onClick: () => {} },
      { label: 'Button 3', onClick: () => {} },
    ],
    dropdownGroupData: {
      dropdownOptions: ['Option 1', 'Option 2', 'Option 3'],
    },
    nextButtonLabel: 'Next',
    icon: 'your-icon', // Vervang dit door de daadwerkelijke icon-data

    imageSrc: './dogcat.jpeg'
  },
  footerData: {
    leftText: ['Home', 'Left Text 2'],
    rightText: ['Right Text 1', 'Right Text 2'],
  },
};