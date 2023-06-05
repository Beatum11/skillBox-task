import React from 'react';
import FormElement from './elements/FormElement';
import Headline from './elements/Headline';
import '../css-files/main.css';

const Main = () => {

  return (
    <div className='main-container'>
        <div className='main-container-upper'>
            <Headline text={'IT consulting for everyone'}/>
            <img alt='office' src='https://images.unsplash.com/photo-1454165804606-c3d57bc86b40?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=870&q=80'/>
        </div>
        <FormElement/>
    </div>
  )

}

export default Main;