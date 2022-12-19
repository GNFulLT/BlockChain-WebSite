import React from 'react'
import styles from "./register.module.scss"
import { PasswordInput, Text, Group, TextInput,  Box, Progress,Center } from '@mantine/core';
import { Button } from '@mantine/core';
import { Check, X } from 'tabler-icons-react';
import { useInputState } from '@mantine/hooks';
import { useMdQuery } from '../../../lib/hooks/Query';

const requirements = [
    { re: /[0-9]/, label: 'Includes number' },
    { re: /[a-z]/, label: 'Includes lowercase letter' },
    { re: /[A-Z]/, label: 'Includes uppercase letter' },
    { re: /[$&+,:;=?@#|'<>.^*()%!-]/, label: 'Includes special symbol' },
  ];

function PasswordRequirement({ meets, label }: { meets: boolean; label: string }) {
    const {mdQuery} = useMdQuery();

    return (
      <Text color={meets ? 'teal' : 'red'} mt={mdQuery ? 3 : 2} size="xs" sx={{fontSize:mdQuery ? 11 : 9}}>
        <Center inline>
          {meets ? <Check size={mdQuery ? 11 : 7} /> : <X size={mdQuery ? 11 : 7} />}
          <Box ml={7}>{label}</Box>
        </Center>
      </Text>
    );
  }
  
  function getStrength(password: string) {
    let multiplier = password.length > 5 ? 0 : 1;
  
    requirements.forEach((requirement) => {
      if (!requirement.re.test(password)) {
        multiplier += 1;
      }
    });
  
    return Math.max(100 - (100 / (requirements.length + 1)) * multiplier, 0);
  }

const Register = () => {
    const {mdQuery} = useMdQuery();
    const [value, setValue] = useInputState('');
    const strength = getStrength(value);
    const checks = requirements.map((requirement, index) => (
      <PasswordRequirement key={index} label={requirement.label} meets={requirement.re.test(value)} />
    ));
    const bars = Array(4)
      .fill(0)
      .map((_, index) => (
        <Progress
          styles={{ bar: { transitionDuration: '0ms' } }}
          value={
            value.length > 0 && index === 0 ? 100 : strength >= ((index + 1) / 4) * 100 ? 100 : 0
          }
          color={strength > 80 ? 'teal' : strength > 50 ? 'yellow' : 'red'}
          key={index}
          size={mdQuery ? 6 : 5}
        />
      ));

  return (
    <form className={styles["container"]}>
        <TextInput styles={{
              root:
              {                
                width:`${mdQuery ? "225px" : "150px"}`,
                minHeight:`${mdQuery ? "30px" : "20px"}`,
                height:`${mdQuery ? "30px" : "20px"}`,
              },
              wrapper:
              { 
                width:`${mdQuery ? "225px" : "150px"}`,
                minHeight:`${mdQuery ? "30px" : "20px"}`,
                height:`${mdQuery ? "30px" : "20px"}`,
              },
              input:
              {
                width:`${mdQuery ? "225px" : "150px"}`,
                minHeight:`${mdQuery ? "30px" : "20px"}`,
                height:`${mdQuery ? "30px" : "20px"}`,
              },             
              label:
              {
                fontSize:`${mdQuery ? "12px" : "10px"}`,               
              }
            }} required type='email' size="xs" label="Email" mb={mdQuery ? 10 : 0}></TextInput>
        <TextInput mt={20} styles={{
             root:
             {                
               width:`${mdQuery ? "225px" : "150px"}`,
               minHeight:`${mdQuery ? "30px" : "20px"}`,
               height:`${mdQuery ? "30px" : "20px"}`,
             },
             wrapper:
             { 
               width:`${mdQuery ? "225px" : "150px"}`,
               minHeight:`${mdQuery ? "30px" : "20px"}`,
               height:`${mdQuery ? "30px" : "20px"}`,
             },
             input:
             {
               width:`${mdQuery ? "225px" : "150px"}`,
               minHeight:`${mdQuery ? "30px" : "20px"}`,
               height:`${mdQuery ? "30px" : "20px"}`,
             },             
             label:
             {
               fontSize:`${mdQuery ? "12px" : "10px"}`,               
             }
            }} required type='text' size="xs" label="Name Surname" mb={mdQuery ? 10 : 0}></TextInput>
            <PasswordInput
            mt={20}
            styles={{
                root:
                {                
                  width:`${mdQuery ? "225px" : "150px"}`,
                  minHeight:`${mdQuery ? "30px" : "20px"}`,
                  height:`${mdQuery ? "30px" : "20px"}`,
                },
                wrapper:
                { 
                  width:`${mdQuery ? "225px" : "150px"}`,
                  minHeight:`${mdQuery ? "30px" : "20px"}`,
                  height:`${mdQuery ? "30px" : "20px"}`,
                },
                input:
                {
                  width:`${mdQuery ? "225px" : "150px"}`,
                  minHeight:`${mdQuery ? "30px" : "20px"}`,
                  height:`${mdQuery ? "30px" : "20px"}`,
                },             
                label:
                {
                  fontSize:`${mdQuery ? "12px" : "10px"}`,               
                },
              innerInput:
              {
                width:`${mdQuery ? "225px" : "150px"}`,
                minHeight:`${mdQuery ? "30px" : "20px"}`,
                height:`${mdQuery ? "30px" : "20px"}`,
                fontSize:`${mdQuery ? "12px" : "10px"}`,               
                "::placeholder":{
                    fontSize:`${mdQuery ? "12px" : "10px"}`,               
                } 
              },
             
            }}
            value={value}
            onChange={setValue}
            placeholder="Your password"
            label="Password"
            required
            />

            <Group sx={{width:mdQuery ? 225 : 150,position:"relative"}} spacing={5} grow mt="40px" mb={10}>
                {bars}
            </Group>

            <div>
            <PasswordRequirement label="Has at least 6 characters" meets={value.length > 5} />
                {checks}
            </div>
            <Button type='submit' mt={mdQuery ? 10 : 20} sx={{
                width:`${mdQuery ? "250px" : "175px"}`,
                height:`${mdQuery ? "32.5px" : "25px"}`,
  }}  styles={{
    label:{
        padding:`${mdQuery ? "0" : "0 0 2.5px 0"}`,
        fontSize:`${mdQuery ? "15px" : "12px"}`,
    }
  }}>
            Register
      </Button>
    </form>
  )
}

export default Register