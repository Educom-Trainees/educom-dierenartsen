import React from 'react';
import ToggleButton from './ToggleButton';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faDog } from '@fortawesome/free-solid-svg-icons';

library.add(faDog);

export default {
  title: 'MOLECULES/ToggleButton',
  component: ToggleButton,
  argTypes: {
    onClick: { action: 'clicked' },
  },
};

const Template = (args) => <ToggleButton {...args} />;

export const Default = Template.bind({});
Default.args = {
  onClick: undefined,
};