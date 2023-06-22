import React, {useState} from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
} from 'reactstrap';
import {
  Dropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from 'reactstrap';

import Home from '../../images/home.png';


function HeaderbarSection() {
  const [collapsed, setCollapsed] = useState(true);
  const toggleNavbar = () => setCollapsed(!collapsed);

  const [dropdownOpen, setDropdownOpen] = useState(false);
  const toggle = () => setDropdownOpen((prevState) => !prevState);

  const [stateItem , setStateItem] = useState("Student");

  const selectItem = ['Student' , 'Subject', 'Teacher','Classroom']

  return (
    <div className="Headerbar">
      <div style={{ display: 'flex', flexDirection: 'column' }}>
        <div>
          <Navbar color="faded" light>
            <NavbarBrand href="/" className="me-auto">Logo</NavbarBrand>
            <NavbarToggler onClick={toggleNavbar} className="me-2" />
            <Collapse isOpen={!collapsed} navbar>
              <Nav navbar>
                <NavItem>
                  <NavLink>Components</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink>GitHub</NavLink>
                </NavItem>
              </Nav>
            </Collapse>
          </Navbar>
        </div>
     <div>
      <Navbar
        color="success"
        dark
        style={{ height: '55px',display: 'flex', alignItems: 'center', justifyContent: 'center'}}
      >
        <div className="d-flex align-items-center">
            <img src={Home} alt='' style={{height:'1.5rem', width:'1.5rem',color:'white'}}/>
            <div className="d-flex mx-3">
              <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                <DropdownToggle caret>{stateItem}</DropdownToggle>
                <DropdownMenu>
                  {selectItem.map((val) => {
                    return <DropdownItem onClick={ () => setStateItem(val)}>
                      {val}
                    </DropdownItem>
                  })}
                </DropdownMenu>
              </Dropdown>
            </div>
        </div>
      </Navbar>
    </div>
  </div>
</div>
  );
}

export default HeaderbarSection;
