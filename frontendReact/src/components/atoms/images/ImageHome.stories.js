import React from 'react';
import ImageHome from './ImageHome';

export default {
  title: 'ATOMS/ImageHome',
  component: ImageHome,
  argTypes: {
    alt: { control: 'text' }, // Voeg dit toe om de alt-tekst aan te passen
  },
};

const Template = (args) => <ImageHome {...args} />;

export const Default = {
  args: {
    alt: 'Dog and Cat', // Geef een standaardwaarde voor de alt-tekst
  },
};