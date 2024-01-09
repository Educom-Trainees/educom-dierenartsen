// button.stories.js
import React from 'react';
import Button from './Button';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCalendarDays, faCoffee } from '@fortawesome/free-solid-svg-icons';

library.add(faCalendarDays);

export default {
  title: 'ATOMS/Button',
  component: Button,
  argTypes: {
    variant: { control: 'text' }, // Voeg dit toe voor de variant
    children: { control: 'text' }, // Voeg dit toe voor de tekst binnen de knop
  },
};

const Template = (args) => <Button {...args} />;

export const Primary = {
  args: {
    Primary: true,
    children: 'Plan afspraak',
  },
};

export const Secondary = {
args: {
  ...Primary.args,
  size:"large",
  children: 'Secondary',
},
};

export const Success = Template.bind({});
Success.args = {
  variant: 'success',
  children: 'Success',
};

export const Danger = Template.bind({});
Danger.args = {
  variant: 'danger',
  children: 'Danger',
};