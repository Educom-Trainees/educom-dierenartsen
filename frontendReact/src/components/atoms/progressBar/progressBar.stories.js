import React from 'react';
import ProgressBar from './progressBar';

export default {
  title: 'Atoms/ProgressBar',
  component: ProgressBar,
};


const Template = (args) => <ProgressBar {...args} />;

export const Default = Template.bind({});
Default.args = {};

export const Running = Template.bind({});
Running.args = { isRunning: true };

export const Filled50Percent = Template.bind({});
Filled50Percent.args = { filled: 50 };

export const Filled75Percent = Template.bind({});
Filled75Percent.args = { filled: 75 };

export const Filled100Percent = Template.bind({});
Filled100Percent.args = { filled: 100 };