import React from "react";
import ButtonBar from "./ButtonBar";
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCalendarDays, faDog, faCat, faOtter } from '@fortawesome/free-solid-svg-icons';

library.add(faCalendarDays, faDog, faCat, faOtter);

export default {
  title: 'MOLECULES/ButtonBar',
  component: ButtonBar,
  argTypes: {
    buttons: { control: 'object' }, // Stel het type in op 'object' voor de buttons-prop
  },
};

const Template = (args) => <ButtonBar {...args} />;

export const Default = Template.bind({});
Default.args = {
  buttons: [
    { label: 'Button 1', onClick: () => console.log('Button 1 clicked') },
    { label: 'Button 2', onClick: () => console.log('Button 2 clicked') },
    { label: 'Button 3', onClick: () => console.log('Button 3 clicked') },
  ],
};

export const WithIcons = Template.bind({});
WithIcons.args = {
  buttons: [
    { icon: faDog, onClick: () => console.log('Button 1 clicked') },
    { icon: faCat, onClick: () => console.log('Button 2 clicked') },
    { icon: faOtter, onClick: () => console.log('Button 3 clicked') },
  ],
};

export const CustomStyles = Template.bind({});
CustomStyles.args = {
  buttons: [
    { label: 'Primary', primary: true, onClick: () => console.log('Primary button clicked') },
    { label: 'Secondary', primary: false, onClick: () => console.log('Secondary button clicked') },
    { label: 'Custom', variant: 'customVariant', onClick: () => console.log('Custom button clicked') },
  ],
};
