import React from 'react';
import subKop from './subKop';

export default {
  title: 'ATOMS/subKop',
  component: subKop,
  argTypes: {
    text: { control: 'text' },
    fontSize: { control: 'text' }, 
    color: { control: 'color' },
  },
};

const Template = (args) => <subKop {...args} />;

export const Default = {
  args: {
    text: 'Bij HappyPaw begrijpen we dat uw huisdier een speciale plaats inneemt in uw hart en gezin. Ons toegewijde team van ervaren dierenartsen staat klaar om de best mogelijke zorg te bieden voor uw trouwe metgezel.',
    fontSize: '16px', 
    color: 'black', 
  },
};