import React, { useState } from 'react';
import {
  Accordion,
  AccordionBody,
  AccordionHeader,
  AccordionItem,
  Button,
  Form,
  FormGroup,
  Input,
  Label,
} from 'reactstrap';

export default function Student(props) {
    const [open, setOpen] = useState('1');
    const toggle = (id) => {
        if (open === id) {
          setOpen();
        } else {
          setOpen(id);
        }
    };

    const classRoomOptions = ['class-A', 'Class-B', 'Class-C', 'Class-D']
    const [classState, setClassState] = useState("Select Your Class");


  return (
    <div style={{padding:'2rem'}}>
      <Accordion open={open} toggle={toggle}>
        <AccordionItem>
          <AccordionHeader targetId="1">Student Details</AccordionHeader>
          <AccordionBody accordionId="1">
          <div > 
          <Form>
              <FormGroup>
                <Label for = "firstName">First Name</Label>
                <Input id='firstName' name='firstName' placeholder='First Name'/>
                <Label for = "lastName">Last Name</Label>
                <Input id='lastName' name='lastName' placeholder='Last Name'/>
                <Label for = "conatctPerson">Contact Person</Label>
                <Input id='contactPerson' name='contactPerson' placeholder='Contact Person'/>
                <Label for = "contactNo">Contact No</Label>
                <Input id='contactNo' name='contactNo' placeholder='Contact No'/>
                <Label for="email">Email</Label>
                <Input id="email"name="email"placeholder="Email"type="email"/>
                <Label for="dob">Date of Birth:</Label>
                <Input type="datetime-local" id="dob" name="dob" min="1900-01-01T00:00"/>
                <Label for="classroom">{classState}</Label>
                <Input id="classroom"name="select"type="select">
                  <option>1</option>
                  <option>2</option>
                  <option>3</option>
                </Input>
              </FormGroup>
            </Form>
          </div>
          <div>
            <Button style={{marginRight:'10px'}} color='success'>Save</Button>
            <Button style={{marginRight:'10px'}} color='danger'>Delete</Button>
            <Button color='warning'>Reset</Button>
          </div>
          </AccordionBody>
        </AccordionItem>
      </Accordion>
    </div>
  )
}

